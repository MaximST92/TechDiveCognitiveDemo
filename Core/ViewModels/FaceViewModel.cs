using CognitiveDemo.Core.Model;
using maximst.CognitiveDemo.Core.ViewModels.Base;

namespace maximst.CognitiveDemo.Core.ViewModels
{
    public class FaceViewModel: BaseViewModel
    {
        public FaceModel Model { get; set; }
        public string ImagePath { get; set; }
    }
}