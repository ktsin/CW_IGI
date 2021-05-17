using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public MessageService(
            IMessageRepository messageRepository,
            IMapper mapper,
            IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public IEnumerable<MessageDTO> GetAll()
        {
            return _messageRepository.GetAll().Select(ToMessageDto);
        }

        public bool SendMessage(int senderId, int recipientId, string msg)
        {
            return _messageRepository.Add(new Message()
            {
                MessageBody = msg,
                SenderId = senderId,
                RecipientId = recipientId
            });
        }

        public IEnumerable<UserDTO> GetAllRecipientsForUser(int userId)
        {
            var ids = _messageRepository
                .GetBySelector(e => e.SenderId == userId || e.RecipientId == userId)
                .Select(e => e.SenderId == userId ? e.RecipientId : e.SenderId)
                .Distinct()
                .Select(e => _userRepository.GetById(e))
                .Select(ToUserDto);
            return ids;
        }

        public IEnumerable<MessageDTO> GetConversation(int current, int right)
        {
            var conversation = _messageRepository.GetBySelector(e => e.RecipientId == current
                                                  || e.SenderId == right
                                                  || e.SenderId == current
                                                  || e.RecipientId == right)
                .OrderBy(e=>e.MessageTime)
                .Select(ToMessageDto);
            return conversation;
        }

        #region Converters

        public MessageDTO ToMessageDto(Message msg)
        {
            return _mapper.Map<Message, MessageDTO>(msg);
        }

        public Message FromMessageDto(MessageDTO msg)
        {
            return _mapper.Map<MessageDTO, Message>(msg);
        }

        public UserDTO ToUserDto(User user)
        {
            return _mapper.Map<User, UserDTO>(user);
        }

        public User FromUserDto(UserDTO user)
        {
            return _mapper.Map<UserDTO, User>(user);
        }

        #endregion
    }
}
