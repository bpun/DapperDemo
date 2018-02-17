using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.Web.Models;
using DapperDemo.Web.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DapperDemo.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            return View(_customerRepository.FindAll());
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public IActionResult Create(Customer cust)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Add(cust);
                return RedirectToAction("Index");
            }
            return View(cust);

        }

        // GET: /Customer/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer obj = _customerRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST: /Customer/Edit   
        [HttpPost]
        public IActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: /Customer/Details/1
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Customer obj = _customerRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // GET:/Customer/Delete/1
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            _customerRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}