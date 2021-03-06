using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.DashboardViewModels
{
    public class DashboardVM
    {
        [Display(Name = "Total Sales")]
        public Decimal TotalSales { get; set; }

        [Display(Name = "Total Sales Today")]
        public Decimal TotalSalesToday { get; set; }

        [Display(Name = "Total Enroll")]
        public int TotalEnroll { get; set; }

        [Display(Name = "Total Enroll Today")]
        public int TotalEnrollToday { get; set; }

        [Display(Name = "Total Courses")]
        public int TotalCourses { get; set; }

        [Display(Name = "Total Courses Today")]
        public int TotalCoursesToday { get; set; }

        [Display(Name = "Total Students")]
        public int TotalStudents { get; set; }

        [Display(Name = "Total Students Today")]
        public int TotalStudentsToday { get; set; }

        [Display(Name = "Total Views")]
        public int TotalViews { get; set; }
        public int TotalSubscriber { get; set; }
        public List<SubmitCoursesVM> SubmitCourses { get; set; }

        public List<LastSellCoursesVM> LastSellCourses { get; set; }
    }
}