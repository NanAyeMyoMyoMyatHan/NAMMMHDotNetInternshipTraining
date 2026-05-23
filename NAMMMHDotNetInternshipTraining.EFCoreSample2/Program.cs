using NAMMMHDotNetInternshipTraining.EFCoreSample2;

EFCoreSample efcore = new EFCoreSample();
efcore.ReadStudents();
efcore.EditSutdent();
efcore.CreateStudent();
efcore.ReadStudents();
efcore.UpdateStudent();
efcore.ReadStudents();
efcore.DeleteStudent();
efcore.ReadStudents();
Console.ReadLine();
