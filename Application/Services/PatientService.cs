using Application.DTO;
using DAL.Entity;
using DAL.Enums;
using DAL.Interfaces;

namespace Application.Services
{
    public class PatientService
    {
        private readonly IPacientStore _pacientStore;
        private readonly ISectionStore _sectionStore;

        public PatientService(IPacientStore pacientStore, ISectionStore sectionStore)
        {
            _pacientStore = pacientStore;
            _sectionStore = sectionStore;
        }

        public void AddPatient(PatientDTO patient)
        {
            if (_sectionStore.IsExist(patient.IdSection))
            {
                Patient temp = new Patient();
                temp.Name = patient.Name;
                temp.Surname = patient.Surname;
                temp.Patronumic = patient.Patronumic;
                temp.Adres = patient.Adres;
                temp.DateBorn = patient.DateBorn;
                temp.Pol = patient.Pol;
                temp.IdSection = patient.IdSection;

                _pacientStore.Add(temp);
            }
            else
            {
                throw new Exception("Выбранный участок не существует.");
            }
        }

        public void EditPatient(PatientDTO patient)
        {
            if (_pacientStore.IsExist(patient.Id))
            {
                Task<Patient> tPacient = _pacientStore.Get(patient.Id);
                tPacient.Wait();
                Patient temp = tPacient.Result;

                temp.Name = patient.Name;
                temp.Surname = patient.Surname;
                temp.Patronumic = patient.Patronumic;
                temp.Adres = patient.Adres;
                temp.DateBorn = patient.DateBorn;
                temp.Pol = patient.Pol;
                temp.IdSection = patient.IdSection;

                Task<int> UpdateTask = _pacientStore.Update(temp);
                UpdateTask.Wait();

                if (UpdateTask.Result == 0)
                {
                    throw new Exception("Редактирование небыло выполнено.");
                }
            }
            else
            {
                throw new Exception("Пациент, которого вы пытаетесь редактировать, не существует.");
            }
        }

        public void DeletePatient(Patient patient) 
        {
            if (_pacientStore.IsExist(patient.IdPatient))
            {
                Task<int> DeleteTask = _pacientStore.Delete(patient);
                DeleteTask.Wait();

                if (DeleteTask.Result == 0)
                {
                    throw new Exception("Удаление небыло выполнено.");
                }
            }
            else
            {
                throw new Exception("Пациент, которого вы пытаетесь удалить, не существует.");
            }
        }

        public Patient GetPatient(int id) 
        {
            if (_pacientStore.IsExist(id))
            {
                Task<Patient> GetTask = _pacientStore.Get(id);
                GetTask.Wait();
                return GetTask.Result;
            }
            else
            {
                throw new Exception("Пациент с данным id не найден.");
            }
        }

        public List<PatientEditDTO> GetPatients(PacientSortOptions option)
        {
            List<Patient> lstPatients = _pacientStore.Get(option);
            List<PatientEditDTO> lstPatientsForEdit = new List<PatientEditDTO>();

            foreach (Patient patient in lstPatients) 
            {
                Task<Section> SectionTask = _sectionStore.GetSection(patient.IdSection);
                SectionTask.Wait();
                Section selSection = SectionTask.Result;

                PatientEditDTO dto = new PatientEditDTO();
                dto.Name = patient.Name;
                dto.Surname = patient.Surname;
                dto.Patronumic = patient.Patronumic;
                dto.Adres = patient.Adres;
                dto.DateBorn = patient.DateBorn;
                dto.Pol = patient.Pol;
                dto.NameSection = selSection.Number.ToString();

                lstPatientsForEdit.Add(dto);
            }

            return lstPatientsForEdit;
        }

    }
}
