using Microsoft.AspNetCore.Components;

namespace TgEng.Components {
    /// <summary>
    /// Обложка курса
    /// </summary>
    public partial class CourseCover {
        /// <summary>
        /// Название курса
        /// </summary>
        [Parameter]
        public string Title {  get; set; }

        /// <summary>
        /// Процент завершености курса
        /// </summary>
        [Parameter]
        public int ComplitionPercentage { get; set; }

        /// <summary>
        /// Путь до изображения-обложки курса
        /// </summary>
        [Parameter]
        public string CoverImagePath {  get; set; }
    }
}
