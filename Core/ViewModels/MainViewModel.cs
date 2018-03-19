using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using CognitiveDemo.Core.Model;
using maximst.CognitiveDemo.Core.Consts;
using maximst.CognitiveDemo.Core.Models;
using maximst.CognitiveDemo.Core.ViewModels.Base;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using FileAccess = PCLStorage.FileAccess;

namespace maximst.CognitiveDemo.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand CameraCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        var takePhotoAsync = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { CompressionQuality = 75 });
                        Dialogs.ShowLoading();
                        var faceModels = await GetFaceResult(takePhotoAsync.Path);
                        using (var vm = GetViewModel<FaceViewModel>())
                        {
                            vm.Model = faceModels.First();
                            vm.ImagePath = takePhotoAsync.Path;
                            Dialogs.HideLoading();
                            await vm.ShowAsync();
                        }
                    }
                    catch (Exception e)
                    {
                        Dialogs.HideLoading();
                        Dialogs.Toast(e.Message);
                    }
                });

            }
        }


        public ICommand VisionCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    try
                    {
                        var mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { CompressionQuality = 75 });
                        Dialogs.ShowLoading();
                        var model = await GetVisionResult(mediaFile.Path);
                        using (var vm = GetViewModel<VisionViewModel>())
                        {
                            vm.Vision = model;
                            vm.ImagePath = mediaFile.Path;
                            Dialogs.HideLoading();
                            await vm.ShowAsync();
                        }
                    }
                    catch (Exception e)
                    {
                        Dialogs.HideLoading();
                        Dialogs.Toast(e.Message);
                    }
                });
            }
        }

        public ICommand TextAnalyticsCommand
        {
            get
            {
                return new RelayCommand(async () =>
              {
                  using (var vm = GetViewModel<AnalyzeTextViewModel>())
                  {
                      await vm.ShowAsync();
                  }
              });
            }
        }
        public FaceModel FaceModel { get; set; }

        private async Task<FaceModel[]> GetFaceResult(string filePath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Api.KeyFace);
                    var requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
                    var uri = Api.UriBaseFace + "?" + requestParameters;
                    var data = await GetImageAsByteArray(filePath);

                    using (ByteArrayContent content = new ByteArrayContent(data))
                    {
                        // This example uses content type "application/octet-stream".
                        // The other content types you can use are "application/json" and "multipart/form-data".
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        // Execute the REST API call.
                        var response = await client.PostAsync(uri, content);

                        // Get the JSON response.
                        string contentString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<FaceModel[]>(contentString);
                    }
                }
            }
            catch (Exception e)
            {
                Dialogs.Toast(e.Message);
                return null;
            }

        }

        private async Task<VisionModel> GetVisionResult(string filePath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var queryString = HttpUtility.ParseQueryString(string.Empty);
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Api.KeyVision);
                    queryString["visualFeatures"] = "Description,Tags,Faces,ImageType,Color,Adult ";
                    queryString["language"] = "en";
                    var uri = Api.UriBaseVision + "?" + queryString;
                    var data = await GetImageAsByteArray(filePath);

                    using (ByteArrayContent content = new ByteArrayContent(data))
                    {
                        // This example uses content type "application/octet-stream".
                        // The other content types you can use are "application/json" and "multipart/form-data".
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        // Execute the REST API call.
                        var response = await client.PostAsync(uri, content);

                        // Get the JSON response.
                        string contentString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<VisionModel>(contentString);

                    }
                }
            }
            catch (Exception e)
            {
                Dialogs.Toast(e.Message);
                return null;
            }

        }
        private async Task<byte[]> GetImageAsByteArray(string imageFilePath)
        {
            var file = await PCLStorage.FileSystem.Current.LocalStorage.GetFileAsync(imageFilePath);
            var fileStream = await file.OpenAsync(FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
    }
}