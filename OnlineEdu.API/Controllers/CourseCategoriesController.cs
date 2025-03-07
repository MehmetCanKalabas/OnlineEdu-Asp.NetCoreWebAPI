﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService _courseCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseCategoryService.TGetList();
            var mappedValues = _mapper.Map<List<ResultCourseCategoryDto>>(values);
            return Ok(mappedValues);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseCategoryService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseCategoryService.TDelete(id);
            return Ok("Kurs Kategori Alanı Silindi.");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDtos createCourseCategoryDtos)
        {
            var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDtos);
            _courseCategoryService.TCreate(newValue);
            return Ok("Yeni Kurs Kategori Alan Oluşturuldu.");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var newValue = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            _courseCategoryService.TUpdate(newValue);
            return Ok("Kurs Kategori Alanı Güncellendi.");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseCategoryService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseCategoryService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }

        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _courseCategoryService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }
    }
}

