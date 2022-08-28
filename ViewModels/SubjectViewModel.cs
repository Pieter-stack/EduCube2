using CommunityToolkit.Mvvm.ComponentModel;
using EduCube.Models;
using EduCube.Services;
using EduCube.Views.AddUpdateViews;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.ViewModels
{
    public partial class SubjectViewModel : ObservableObject
    {
        public ObservableCollection<SubjectModel> Subjects { get; set; } = new ObservableCollection<SubjectModel>();

        private readonly ISubjectService _subjectRepository;
        public SubjectViewModel(ISubjectService subjectService)
        {
            _subjectRepository = subjectService;
        }

        [ObservableProperty]
        string search;

        [ICommand]
        public async void GetSubjectList()
        {
            var subjectList = await _subjectRepository.GetSubjectList();
            if (subjectList?.Count > 0)
            {
                Subjects.Clear();
                foreach(var subject in subjectList)
                {
                    Subjects.Add(subject);  
                }
            }
        }

        [ICommand]
        public  async void GetSubjectListSearch()
        {
            var subjectList = await _subjectRepository.GetSubjectList();
            var filteredItems = subjectList.Where(value => value.SubjectTitle.ToLowerInvariant().Contains(Search)).ToList();

            Subjects.Clear();
            foreach (var subject in filteredItems)
            {
                Subjects.Add(subject);
            }  
        }

        [ICommand]
        public async void AddUpdateSubject()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateSubjectPage));
        }

        [ICommand]
        public async void DisplayAction(SubjectModel subjectModel)
        {
           var response = await AppShell.Current.DisplayActionSheet("Select Option","OK",null,"Edit","Delete");
            if(response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("SubjectDetail", subjectModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateSubjectPage),navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _subjectRepository.DeleteSubject(subjectModel);
                if(delResponse > 0)
                {
                    GetSubjectList();
                }
            }
        }
    }
}
