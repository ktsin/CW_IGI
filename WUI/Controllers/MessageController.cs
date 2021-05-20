using System;
using System.Linq;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WUI.Auth;

namespace WUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;
        private readonly UserManager<WebUser> _user;

        public MessageController(MessageService messageService, UserManager<WebUser> user)
        {
            _messageService = messageService;
            _user = user;
        }

        // GET
        [Authorize]
        public IActionResult Index()
        {
            if ((!User.Identity?.IsAuthenticated) ?? false)
            {
                return NotFound();
            }

            var uname = User.Identity?.Name;
            var id = _user.Users.FirstOrDefault(e => e.UserName == uname)?.UnderlyingUserId;
            return View("Dialogues", _messageService.GetAllRecipientsForUser(id ?? -1));
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            if ((!User.Identity?.IsAuthenticated) ?? false)
            {
                return NotFound();
            }

            var uname = User.Identity?.Name;
            var uid = _user.Users.FirstOrDefault(e => e.UserName == uname)?.UnderlyingUserId;
            var conversations = _messageService.GetConversation(uid ?? -1, id);
            return View("DialogueDetails", conversations);
        }

        [HttpPost]
        public IActionResult Send(string messageBody, int senderId, int recipientId)
        {
            var res = new ContentResult {Content = "Message sent!"};
            if (messageBody?.Length == 0)
                res.Content = "Message must be > 0 symbols!";
            else
            {
                try
                {
                    if (_messageService.SendMessage(senderId, recipientId, messageBody))
                        res.Content = "Exception occures, try again later!";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    res.Content = "Exception occures, try again later!";
                }
            }
            return res;
        }
    }
}