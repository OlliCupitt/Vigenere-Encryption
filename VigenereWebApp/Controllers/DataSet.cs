using Microsoft.AspNetCore.Mvc;
using VigenereWebApp;
using Microsoft.AspNetCore.Mvc;

namespace VigenereWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataSetController : ControllerBase
    {
        private readonly VigenereCipher _vigenereCipher;


        public DataSetController(VigenereCipher vigenereCipher)
        {
            _vigenereCipher = vigenereCipher;
        }

        [HttpPost("encrypt")]
        public ActionResult<string> Encrypt([FromBody] DataSet request)
        {
            if (string.IsNullOrEmpty(request.Text) || string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("Text and key are required!");
            }

            string encryptedText = _vigenereCipher.Encrypt(request.Text, request.Key);
            return Ok(encryptedText);
        }
        [HttpPost("decrypt")]
        public ActionResult<string> Decrypt([FromBody] DataSet request)
        {
            if (string.IsNullOrEmpty(request.Text) || string.IsNullOrEmpty(request.Key))
            {
                return BadRequest("Text and key are required!");
            }

            string decryptedText = _vigenereCipher.Decrypt(request.Text, request.Key);
            return Ok(decryptedText);
        }
    }
}

