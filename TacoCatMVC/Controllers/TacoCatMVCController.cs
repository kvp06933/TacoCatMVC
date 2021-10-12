using TacoCatMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TacoCatMVC.Controllers
{
    public class TacoCatMVCController : Controller
    {
        [HttpPost]
        public IActionResult Index(TacoCat TacoCat)
        {

            string userInput = TacoCat.UserInput;
            string revWord = "";

            for (int i = userInput.Length-1; i >= 0; i--)
            {
                revWord += userInput[i];

            }
            TacoCat.RevWord = revWord;
            revWord = Regex.Replace(revWord.ToLower(),"[^a-zA-Z0-9]+","");
            userInput = Regex.Replace(userInput.ToLower(), "[^a-zA-Z0-9]+", "");

            if(revWord == userInput)
            {
                TacoCat.IsPalindrome = true;
                TacoCat.Message = $"Success {TacoCat.UserInput} is a palindrome";
            }
            else
            {
                TacoCat.IsPalindrome = false;
                TacoCat.Message = $"Sorry {TacoCat.UserInput} is NOT a palindrome";
            }

            return View(TacoCat);

        }
        [HttpGet]
        public IActionResult Index()
        {
            TacoCat TacoCat = new();
            
            return View(TacoCat);
        }
        
    }
}
