using Application.DTO;
using DAL.Entity;
using DAL.Enums;
using DAL.Interfaces;

namespace Application.Services
{
    public class DoctorService
    {
        private readonly IDoctorStore _doctorStore;
        private readonly ISectionStore _sectionStore;
        private readonly ISpecializationStore _specializationStore;

        public DoctorService(IDoctorStore doctorStore, ISectionStore sectionStore, ISpecializationStore specializationStore)
        {
            _doctorStore = doctorStore;
            _sectionStore = sectionStore;
            _specializationStore = specializationStore;
        }

        public void AddDoctor(DoctorDTO doctor)
        {
            if (_sectionStore.IsExist(doctor.IdSection))
            {
                if (_specializationStore.IsExist(doctor.IdSpec))
                {
                    Doctor temp = new Doctor();
                    temp.Name = doctor.Name;
                    temp.Surname = doctor.Surname;
                    temp.Patronumic = doctor.Patronumic;
                    temp.IdSection = doctor.IdSection;
                    temp.IdSpec = doctor.IdSpec;

                    _doctorStore.Add(temp).Wait();
                }
                else
                {
                    throw new Exception("Выбранная специализация не существует.");
                }
            }
            else
            {
                throw new Exception("Выбранный участок не существует.");
            }
        }

        public void EditDoctor(DoctorDTO doctor)
        {
            if (_doctorStore.IsExist(doctor.Id))
            {
                Task<Doctor> tDoctor = _doctorStore.Get(doctor.Id);
                tDoctor.Wait();
                Doctor temp = tDoctor.Result;

                temp.Name = doctor.Name;
                temp.Surname = doctor.Surname;
                temp.Patronumic = doctor.Patronumic;
                temp.IdSection = doctor.IdSection;
                temp.IdSpec = doctor.IdSpec;

                Task<int> UpdateTask = _doctorStore.Update(temp);
                UpdateTask.Wait();

                if (UpdateTask.Result == 0)
                {
                    throw new Exception("Редактирование небыло выполнено.");
                }
            }
            else
            {
                throw new Exception("Доктор, которого вы пытаетесь редактировать, не существует.");
            }
        }

        public void DeleteDoctor(Doctor doctor)
        {
            if (_doctorStore.IsExist(doctor.IdDoctor))
            {
                Task<int> DeleteTask = _doctorStore.Delete(doctor);
                DeleteTask.Wait();

                if (DeleteTask.Result == 0)
                {
                    throw new Exception("Удаление небыло выполнено.");
                }
            }
            else
            {
                throw new Exception("Доктор, которого вы пытаетесь удалить, не существует.");
            }
        }

        public Doctor GetDoctor(int id)
        {
            if (_doctorStore.IsExist(id))
            {
                Task<Doctor> GetTask = _doctorStore.Get(id);
                GetTask.Wait();
                return GetTask.Result;
            }
            else
            {
                throw new Exception("Доктор с данным id не найден.");
            }
        }

        public List<DoctorEditDTO> GetDoctors(DoctorSortOptions option)
        {
            List<Doctor> lstDoctors = _doctorStore.Get(option);
            List<DoctorEditDTO> lstDoctorsForEdit = new List<DoctorEditDTO>();

            foreach (Doctor doctor in lstDoctors)
            {
                Task<Section> SectionTask = _sectionStore.GetSection(doctor.IdSection);
                SectionTask.Wait();
                Section selSection = SectionTask.Result;

                Task<Specialization> SpecTask = _specializationStore.GetSpecialization(doctor.IdSpec);
                SpecTask.Wait();
                Specialization selSpec = SpecTask.Result;

                DoctorEditDTO dto = new DoctorEditDTO();
                dto.Name = doctor.Name;
                dto.Surname = doctor.Surname;
                dto.Patronumic = doctor.Patronumic;
                dto.NameSection = selSection.Number.ToString();
                dto.NameSpec = selSpec.Name;

                lstDoctorsForEdit.Add(dto);
            }

            return lstDoctorsForEdit;
        }
    }
}
