using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Technical_Request.Data;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocksController : ControllerBase
    {
        private readonly TechnicalRequestContext context;
        private DbSet<Block> Blocks
        {
            get { return context.Blocks; }
        }

        public BlocksController(TechnicalRequestContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Block>>> GetBlocks()
        {
            return Ok(await Blocks.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Block>> GetBlockByID(int id)
        {
            Block? block = await Blocks.FindAsync(id);
            if (block == null)
            {
                return NotFound();
            }
            return Ok(block);
        }

        [HttpPost]
        public async Task<ActionResult<Block>> CreateBlock(Block newBlock)
        {
            if (newBlock == null)
            {
                return BadRequest();
            }

            Block? existingBlock = await Blocks.FirstOrDefaultAsync(b=>b.Code == newBlock.Code);
            if (existingBlock != null)
            {
                return Conflict();
            }


            Blocks.Add(newBlock);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBlockByID), new { id = newBlock.Id }, newBlock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBlock(int id, Block editedBlock)
        {
            if (editedBlock == null)
            {
                return BadRequest();
            }
            Block? blockToEdit = await Blocks.FindAsync(id);
            if (blockToEdit == null)
            {
                return NotFound();
            }
            if (blockToEdit.Id != editedBlock.Id)
            {
                return BadRequest("You cannot change a block's ID");
            }
            Block? testBlock = await Blocks.FirstOrDefaultAsync(b => b.Code == editedBlock.Code);
            if(testBlock != null && blockToEdit.Code != testBlock.Code)
            {
                return Conflict();
            }
            blockToEdit.Name = editedBlock.Name;
            blockToEdit.Code = editedBlock.Code;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlock(int id)
        {
            Block? blockToDelete = await Blocks.FindAsync(id);
            if (blockToDelete == null)
            {
                return NotFound();
            }

            Blocks.Remove(blockToDelete);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
