/* DownloadGameProduct.cs
 * Purpose: Class for a downloadable demo/shareware game
 * 
 * Revision History:
 *      Drew Matheson, 2015.10.02: Created
 */

using System.ComponentModel.DataAnnotations;

namespace Veil.DataModels.Models
{
    /// <summary>
    /// A downloadable game product
    /// </summary>
    public class DownloadGameProduct : GameProduct
    {
        /// <summary>
        /// The game's download url
        /// </summary>
        [Required]
        [DataType(DataType.Url)]
        [MaxLength(2048)]
        public string DownloadLink { get; set; }

        /// <summary>
        /// An approximate size in megabytes for the download
        /// </summary>
        [Range(0, int.MaxValue)]
        public int ApproximateSizeInMB { get; set; }
    }
}