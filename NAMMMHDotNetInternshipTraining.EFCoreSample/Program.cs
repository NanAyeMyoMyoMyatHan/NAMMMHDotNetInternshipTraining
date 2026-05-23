using NAMMMHDotNetInternshipTraining.EFCoreSample;

EFCoreSample efcore = new EFCoreSample();
efcore.ReadStudents();
efcore.CreateStudent();
efcore.UpdateStudent();
efcore.ReadStudents();
efcore.DeleteStudent();
efcore.EditSutdent();

Console.ReadLine();