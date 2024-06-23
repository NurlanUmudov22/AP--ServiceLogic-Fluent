using API_Intro.Data;
using API_Intro.DTOs.Sliders;
using API_Intro.Models;
using API_Intro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace API_Intro.Services
{
    public class SliderService : ISliderService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SliderService(IWebHostEnvironment webHostEnvironment,
                             AppDbContext context,
                             IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(SliderCreateDto request)
        {
           //var path = Directory.GetCurrentDirectory();


            string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
            
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images" , fileName);

            using (FileStream stream = new(path, FileMode.Create))
            {
               await  request.UploadImage.CopyToAsync(stream);
            }

            request.Image = fileName;

            var mappedData = _mapper.Map<Slider>(request);

            await _context.Sliders.AddAsync(mappedData);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSlider = await _context.Sliders.FindAsync(id);

            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", existSlider.Image);

            if(File.Exists(path))
                File.Delete(path); 

            _context.Sliders.Remove(existSlider);
            
            await _context.SaveChangesAsync();  

        }

        public async Task EditAsync(int id, SliderEditDto request)
        {
            var existSlider = await _context.Sliders.FindAsync(id);
            if(request.UploadImage == null)
            {
                string oldPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", existSlider.Image);

                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
          
                string newPath = Path.Combine(_webHostEnvironment.WebRootPath, "images" , fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await request.UploadImage.CopyToAsync(stream);
                }

                request.Image = fileName;

            }
            //else
            //{
            //    request.Image = existSlider.Image;
            //}



            _mapper.Map(request , existSlider);

            await _context.SaveChangesAsync();


        }

        public async  Task<List<SliderDto>> GetAllAsync()
        {
            return   _mapper.Map<List<SliderDto>>(await _context.Sliders.AsNoTracking().ToListAsync());
        }

        public async Task<SliderDto> GetByIdAsync(int id)
        {
            return _mapper.Map<SliderDto>(await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(m=>m.Id == id));
        }
    }
}
