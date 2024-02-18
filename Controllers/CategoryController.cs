﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using reviewAppWebAPI.Dto;
using reviewAppWebAPI.Interfaces;
using reviewAppWebAPI.Model;
using reviewAppWebAPI.Repository;
using System.Collections.Generic;

namespace reviewAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);

        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>> (_categoryRepository.GetPokemonByCategory(categoryId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(pokemons);


        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            if(categoryCreate == null)
                return BadRequest(ModelState);
            var category = _categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.ToUpper())
                .FirstOrDefault();

            if(category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var categoryMap = _mapper.Map<Category>(categoryCreate);
            if (!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto categoryUpdate)
        {
            if(categoryUpdate == null)
                return BadRequest(ModelState);
            if(categoryId != categoryUpdate.Id)
                return BadRequest(ModelState);
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();
            if(!ModelState.IsValid)
                return BadRequest();

            var categoryMap = _mapper.Map<Category>(categoryUpdate);
            if (!_categoryRepository.UpdateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong on updating category");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
