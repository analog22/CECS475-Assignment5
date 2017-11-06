using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IStandardRepository _standardRepository;
        private readonly IStudentRepository _studentRepository;

        public BusinessLayer()
        {
            _standardRepository = new StandardRepository();
            _studentRepository = new StudentRepository();
        }

        #region Standard
        public IList<Standard> GetAllStandards()
        {
            throw new NotImplementedException();
        }

        public Standard GetStandardByID(int id)
        {
            throw new NotImplementedException();
        }

        public Standard GetStandardByName(string name)
        {
            return _standardRepository.GetSingle(
                s => s.StandardName.Equals(name),
                s => s.Students);
        }

        public void AddStandard(Standard standard)
        {
            _standardRepository.Insert(standard);
        }
        #endregion

        #region Student
        public IList<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Standard GetStandardByIDWithStudents(int id)
        {
            return _standardRepository.GetSingle(
                s => s.StandardId == id,
                s => s.Students);
        }

        public Student GetStudentByID(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByName(string name)
        {
            return _studentRepository.GetSingle(
                s => s.StudentName.Equals(name),
                s => s.Standard);
        }

        public void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}