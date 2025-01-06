﻿using Microsoft.AspNetCore.Mvc;
using Students.Model;

namespace StudentWebApp.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherManager teacherManager;

        public TeacherController(ITeacherManager teacherManager)
        {
            this.teacherManager = teacherManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterTeachers()
        {
            return View();
        }

        // Form beküldésea weboldalról
        public IActionResult RegisterTeacher(Teacher teacher)
        {
            teacherManager.Add(teacher);
            return RedirectToAction("Index");
        }
    }
}
