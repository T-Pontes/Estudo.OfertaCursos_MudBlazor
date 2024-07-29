SELECT      Classes.ClassCode as 'Turma',
            Courses.NameCourse as 'Curso',
            Courses.Workload as 'Ch',
            Classes.StartDate as 'Início',
            Classes.EndDate as 'Término',
            Instructors.Name as 'Nome do Instrutor',
            Students.Enrollment as 'RA',
            Students.Name as 'Nome do Aluno'

FROM        Enrollments
INNER JOIN  Classes
ON          Enrollments.ClassId = Classes.Id
INNER JOIN  Students
ON          Enrollments.StudentId = Students.Id
INNER JOIN  Courses
ON          Classes.CourseId = Courses.Id
INNER JOIN  Instructors
ON          Classes.InstructorId = Instructors.Id