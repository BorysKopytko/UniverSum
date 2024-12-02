using System;
using UniverSum.Client.Identity;
using UniverSum.Client.Services;

namespace UniverSum.Client.Pages;

public partial class RegistrationPage : ContentPage
{
    private readonly RegistrationService registrationService;

    public RegistrationPage()
    {
        InitializeComponent();
        registrationService = new RegistrationService();
        var task = Task.Run(LoadFaculties);
        task.Wait();
    }

    public async Task LoadFaculties()
    {
        var faculties = await registrationService.GetFacultiesAsync();
        FacultyPicker.ItemsSource = faculties.ToList();
    }

    private async void FacultyPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var educationLevels = await registrationService.GetEducationLevelsAsync(FacultyPicker.SelectedItem.ToString());
        EducationLevelPicker.ItemsSource = educationLevels.ToList();
    }

    private async void EducationLevelPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var specialities = await registrationService.GetSpecialitiesAsync(FacultyPicker.SelectedItem.ToString(),
            EducationLevelPicker.SelectedItem.ToString());
        SpecialityPicker.ItemsSource = specialities.ToList();
    }

    private async void SpecialityPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var specialityCourses = await registrationService.GetSpecialityCoursesAsync(FacultyPicker.SelectedItem.ToString(),
            EducationLevelPicker.SelectedItem.ToString(), SpecialityPicker.SelectedItem.ToString());
        SpecialityCoursePicker.ItemsSource = specialityCourses.ToList();
    }

    private async void SpecialityCoursePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var streams = await registrationService.GetStreamsAsync(FacultyPicker.SelectedItem.ToString(),
            EducationLevelPicker.SelectedItem.ToString(), SpecialityPicker.SelectedItem.ToString(), SpecialityCoursePicker.SelectedItem.ToString());
        StreamPicker.ItemsSource = streams.ToList();
    }

    private async void StreamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var groups = await registrationService.GetGroupsAsync(FacultyPicker.SelectedItem.ToString(),
            EducationLevelPicker.SelectedItem.ToString(), SpecialityPicker.SelectedItem.ToString(), SpecialityCoursePicker.SelectedItem.ToString(),
            StreamPicker.SelectedItem.ToString());
        GroupPicker.ItemsSource = groups.ToList();
    }

    private async void RegistrationButton_Clicked(object sender, EventArgs e)
    {
        var registerModel = new RegisterModel
        {
            Email = EmailEntry.Text,
            Password = PasswordEntry.Text,
            LastName = LastNameEntry.Text,
            FirstName = FirstNameEntry.Text,
            MiddleName = MiddleNameEntry.Text,
            Faculty = FacultyPicker.SelectedIndex.ToString(),
            EducationLevel = EducationLevelPicker.SelectedIndex.ToString(),
            Speciality = SpecialityPicker.SelectedIndex.ToString(),
            SpecialityCourse = SpecialityCoursePicker.SelectedIndex.ToString(),
            Stream = StreamPicker.SelectedIndex.ToString(),
            Group = GroupPicker.SelectedIndex.ToString()

        };

        await registrationService.RegisterAsync(registerModel);
    }
}