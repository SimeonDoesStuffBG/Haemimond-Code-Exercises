using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocksController : ControllerBase
    {
        private static List<Block> blocks = new List<Block>
        {
            
        };

        [HttpGet]
        public ActionResult<List<Block>> GetBlocks()
        {
            return Ok(blocks);
        }

        [HttpGet("{id}")]
        public ActionResult<Block> GetBlockByID(int id)
        {
            Block? block = blocks.FirstOrDefault(b => b.Id == id);
            if (block == null)
            {
                return NotFound();
            }
            return Ok(block);
        }

        [HttpPost]
        public ActionResult<Block> CreateBlock(Block newBlock)
        {
            if (newBlock == null)
            {
                return BadRequest();
            }

            Block? existingBlock = blocks.FirstOrDefault(b => b.Id == newBlock.Id || b.Code == newBlock.Code);
            if (existingBlock != null)
            {
                return Conflict();
            }

            blocks.Add(newBlock);
            return CreatedAtAction(nameof(GetBlockByID), new { id = newBlock.Id }, newBlock);
        }

        [HttpPut("{id}")]
        public IActionResult EditBlock(int id, Block editedBlock)
        {
            if (editedBlock == null)
            {
                return BadRequest();
            }
            Block? blockToEdit = blocks.FirstOrDefault(b => b.Id == id);
            if (blockToEdit == null)
            {
                return NotFound();
            }
            Block? testBlock = blocks.FirstOrDefault(b => b.Id == editedBlock.Id);
            if (testBlock != null && blockToEdit.Id != testBlock.Id) 
            {
                return Conflict();
            }
            testBlock = blocks.FirstOrDefault(b => b.Code == editedBlock.Code);
            if(testBlock != null && blockToEdit.Code != testBlock.Code)
            {
                return Conflict();
            }
            blockToEdit.Id = editedBlock.Id;
            blockToEdit.Name = editedBlock.Name;
            blockToEdit.Code = editedBlock.Code;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlock(int id)
        {
            Block? blockToDelete = blocks.FirstOrDefault(b => b.Id == id);
            if (blockToDelete == null)
            {
                return NotFound();
            }

            blocks.Remove(blockToDelete);
            return NoContent();
        }
    }
}
