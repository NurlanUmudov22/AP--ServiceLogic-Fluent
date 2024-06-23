using API_Intro.DTOs.Sliders;

namespace API_Intro.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderCreateDto request);

        Task<List<SliderDto>> GetAllAsync();

        Task<SliderDto> GetByIdAsync(int id);

        Task DeleteAsync(int id);

        Task EditAsync(int id, SliderEditDto request);
    }
}
