
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EduCube.Models;
using EduCube.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduCube.ViewModels.AddUpdateViewModels
{ 
    [QueryProperty(nameof(SubjectDetail), "SubjectDetail")]


    public partial class AddUpdateSubjectViewModel : ObservableObject
    {

        

        [ObservableProperty]
        public SubjectModel _subjectDetail = new SubjectModel();

            private readonly ISubjectService _subjectRepository;
            public  AddUpdateSubjectViewModel(ISubjectService subjectService)
            {
            _subjectRepository = subjectService;



            listOfLecturers = new List<StaffModel>();
            GetListOfLecturers();

            }




        //list of lecturers observable property
        [ObservableProperty]
        List<StaffModel> listOfLecturers;

        [ObservableProperty]
        StaffModel selectedLecturer;


        public async void GetListOfLecturers()
        {
            ListOfLecturers = await App.StaffRepo.GetStaffList();
        }



        [ICommand]
            public async void AddUpdateSubject()
            {
            int response = -1;
            if (SubjectDetail.SubjectID > 0)
            {
                response = await _subjectRepository.EditSubject(SubjectDetail);
            }
            else
            {
                response = await _subjectRepository.AddSubject(new Models.SubjectModel
                {
                    SubjectTitle = SubjectDetail.SubjectTitle,
                    SubjectCode = SubjectDetail.SubjectCode,
                    SubjectLecturer = SelectedLecturer.StaffFirstName,
                    SubjectDescription = SubjectDetail.SubjectDescription,
                    SubjectCredits = SubjectDetail.SubjectCredits,
                    SubjectPrice = SubjectDetail.SubjectPrice,
                    SubjectDate = SubjectDetail.SubjectDate,
                    SubjectTime = SubjectDetail.SubjectTime,
                    SubjectImage = SubjectDetail.SubjectImage,
                    SubjectHours = SubjectDetail.SubjectHours,
                    SubjectVenue = SubjectDetail.SubjectVenue
                });
            }

                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Subject info saved", "Record Saved", "OK");
                   
                }
                else
                {
                    await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
                }

            }
            

        }
    }

