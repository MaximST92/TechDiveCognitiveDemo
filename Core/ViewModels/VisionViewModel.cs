using maximst.CognitiveDemo.Core.Models;
using maximst.CognitiveDemo.Core.ViewModels.Base;

namespace maximst.CognitiveDemo.Core.ViewModels
{
    public class VisionViewModel: BaseViewModel
    {
        public VisionModel Vision { get; set; }
        public string ImagePath { get; set; }

    }
}