using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GrmMusic.Domain
{
    public static class Constants
    {
    }
    public enum DistributionMechanism
    {
        [Display(Name="Digital Download")]
        digitaldownload,
        [Display(Name="Streaming")]
        streaming
    }

}