using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository = null;
        private readonly IMapper _mapper = null;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
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

        public MessageDTO ToMessageDto(Message msg)
        {
            return _mapper.Map<Message, MessageDTO>(msg);
        }
        
        public Message FromMessageDto(MessageDTO msg)
        {
            return _mapper.Map<MessageDTO, Message>(msg);
        }
    }
}