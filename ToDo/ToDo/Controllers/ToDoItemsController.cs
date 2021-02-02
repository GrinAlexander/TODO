using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.ViewModels;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoItemsContext _context;
        private readonly IMapper _mapper;

        public ToDoItemsController(ToDoItemsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<ActionResult<List<ToDoItemViewModel>>> Get()
        {
            var toDoItems = await _context.ToDoItems.Where(x => x.IsActive).ToListAsync();
            var mappedItems = _mapper.Map<List<ToDoItemViewModel>>(toDoItems);
            return Ok(mappedItems);
        }

        // GET api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemViewModel>> Get(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);

            if (toDoItem == null)
                return NotFound("Item with required id not found");

            var mappedItem = _mapper.Map<ToDoItemViewModel>(toDoItem);
            return Ok(mappedItem);
        }

        // POST api/ToDoItems
        [HttpPost]
        public async Task<ActionResult<ToDoItemViewModel>> Post(ToDoItemCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoItemObj = _mapper.Map<ToDoItem>(model);
            _context.ToDoItems.Add(toDoItemObj);
            await _context.SaveChangesAsync();

            var createdToDoItem = await _context.ToDoItems.FindAsync(toDoItemObj.Id);
            var mappedItem = _mapper.Map<ToDoItemViewModel>(createdToDoItem);
            return Ok(mappedItem);
        }

        // PUT api/ToDoItems
        [HttpPut]
        public async Task<ActionResult<ToDoItemViewModel>> Put(ToDoItemUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoItemObj = await _context.ToDoItems.FindAsync(model.Id);
            if (toDoItemObj == null)
            {
                return NotFound("Item with required id not found");
            }

            toDoItemObj = _mapper.Map(model, toDoItemObj);
            _context.ToDoItems.Update(toDoItemObj);
            await _context.SaveChangesAsync();

            var updatedToDoItem = await _context.ToDoItems.FindAsync(toDoItemObj.Id);
            var mappedItem = _mapper.Map<ToDoItemViewModel>(updatedToDoItem);
            return Ok(mappedItem);

        }

        // DELETE api/ToDoItemsController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItemViewModel>> Delete(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound("Item with required id not found");
            }

            toDoItem.IsActive = false;
            await _context.SaveChangesAsync();

            var mappedItem = _mapper.Map<ToDoItemViewModel>(toDoItem);
            return Ok(mappedItem);
        }
    }
}
