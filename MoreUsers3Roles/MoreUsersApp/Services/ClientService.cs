using MoreUsersApp.Abstractions;
using MoreUsersApp.Data;
using MoreUsersApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoreUsersApp.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateClient(string firstName, string lastName, string phone, DateTime birthDate, string userId)
        {
            if (_context.Clients.Any(p => p.UserId == userId))
            {
                throw new InvalidOperationException("Client already exist.");
            }
            Client clientFromDb = new Client()
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                BirthDate = birthDate,
                UserId = userId
            };
            _context.Clients.Add(clientFromDb);

            return _context.SaveChanges() != 0;
        }

        public Client GetClientById(int clientId)
        {
            throw new NotImplementedException();
        }

        public Client GetClientByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClients()
        {
            List<Client> clients = _context.Clients.ToList();

            return clients;
        }

        public string GetFullName(int clientId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
