using DemoSubPrj.Models;
using DemoSubPrj.Views;
using Microsoft.Xaml.Behaviors.Core;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DemoSubPrj.ViewModels
{
    public class DemoPrjVM : BindableBase
    {


        public DemoPrjVM() 
        {
            _models = new SubPrjM();
            _service = new SubPrjService();
            ItemSrcList = new List<SubPrjM>();

            ItemSrcList =_service.GetDataService();
        }
        public SubPrjM _models { get; set; }
        public SubPrjService _service { get; set; }


        public List<SubPrjM> _itemsrclist;

        public List<SubPrjM> ItemSrcList
        {
            get { return _itemsrclist; }
            set
            {
                _itemsrclist = value;
                RaisePropertyChanged(nameof(ItemSrcList));
            }
        }

        private string _comboselected;

        public string ComboSelected
        {
            get { return _comboselected; }
            set
            {
                // Extract data after colon
                int colonIndex = value.IndexOf(':');
                if (colonIndex != -1 && colonIndex + 1 < value.Length)
                {
                    _comboselected = value.Substring(colonIndex + 1).Trim();
                }
                else
                {
                    _comboselected = value; // Fallback to the original value if colon is not found
                }
                RaisePropertyChanged(nameof(ComboSelected));
            }
        }



        private SubPrjM _selecteddata;

        public SubPrjM SelectedData
        {
            get { return _selecteddata; }
            set { _selecteddata = value;
                RaisePropertyChanged(nameof(SelectedData));
            }
        }


        private string _selectedsearchcomboboxvalue;

        public string SelectedSearchComboBoxValue
        {
            get { return _selectedsearchcomboboxvalue; }
            set {

                int colonIndex = value.IndexOf(':');
                if (colonIndex != -1 && colonIndex + 1 < value.Length)
                {
                    _selectedsearchcomboboxvalue = value.Substring(colonIndex + 1).Trim();
                }
                else
                {
                    _selectedsearchcomboboxvalue = value; // Fallback to the original value if colon is not found
                }
                RaisePropertyChanged(nameof(ComboSelected));


            }
        }

        private string _searchtextbox;

        public string SearchTextBox
        {
            get { return _searchtextbox; }
            set {
                _searchtextbox = value;
                RaisePropertyChanged(nameof(SearchTextBox));
                SearchFun();
            }
        }


        public void SearchFun()
        {
            if (string.IsNullOrEmpty(SearchTextBox))
            {
                ItemSrcList = _service.GetDataService();
            }
            else
            {
                List<SubPrjM> FilteredList = new List<SubPrjM>();
                foreach (var item in _service.GetDataService())
                {
                    bool property = item.GetType().GetProperty(SelectedSearchComboBoxValue).GetValue(item, null).ToString().Contains(SearchTextBox);
                    if (property)
                    {
                        FilteredList.Add(item);
                    }
                }
                ItemSrcList = FilteredList;
            }
        }


        public ICommand AddBtnCmd => new ActionCommand(AddPop);

        public AddPop Addpopup { get; set; }


        public ICommand AddSaveBtnCmd => new ActionCommand(AddSaveFun);

        public ICommand EditBtnCmd => new ActionCommand(EditPop);

        public ICommand DeleteBtnCmd => new ActionCommand(DeleteFun);


        public void AddPop()
        {
            Addpopup = new AddPop();
            Addpopup.DataContext = this;
            Addpopup.ShowDialog();
            ClearVals();

        }


        public void DeleteFun()
        {
            _service.DeleteData(SelectedData);
            ItemSrcList.Remove(SelectedData);
        }

        public void EditPop()
        {
            // Assuming AddPop is a Window or UserControl
            Addpopup = new AddPop();
            Addpopup.Title = "Edit Popup";
            _models.Emp_id = SelectedData.Emp_id;
            _models.Emp_name = SelectedData.Emp_name;
            _models.Emp_age = SelectedData.Emp_age;
            _models.Emp_salary = SelectedData.Emp_salary;
            _models.Emp_department = SelectedData.Emp_department;
            _models.Emp_gender = ComboSelected;
            _models.Emp_pno = SelectedData.Emp_pno;
            _models.Emp_designation = SelectedData.Emp_designation;
            Addpopup.DataContext = this;
            Addpopup.ShowDialog();
            ClearVals();
        }


        public void AddSaveFun()
        {
            if (_models.Emp_id == 0)
            {
                SubPrjM addModel = new SubPrjM { Emp_name = _models.Emp_name, Emp_age = _models.Emp_age, Emp_salary = _models.Emp_salary, Emp_department = _models.Emp_department, Emp_gender = ComboSelected.ToString(), Emp_pno = _models.Emp_pno, Emp_designation = _models.Emp_designation };
                _service.AddData(addModel);
                ItemSrcList.Add(addModel);

            }
            else
            {
                SubPrjM editModel = new SubPrjM {Emp_id = SelectedData.Emp_id, Emp_name = _models.Emp_name, Emp_age = _models.Emp_age, Emp_salary = _models.Emp_salary, Emp_department = _models.Emp_department, Emp_gender = ComboSelected.ToString(), Emp_pno = _models.Emp_pno, Emp_designation = _models.Emp_designation };
                _service.UpdateData(editModel);
                ItemSrcList = _service.GetDataService();
            }
            Addpopup.Close();
            ClearVals();
        }

        public void ClearVals()
        {
            _models.Emp_id = 0;
            _models.Emp_name = null;
            _models.Emp_age = 0;
            _models.Emp_salary = 0;
            _models.Emp_department = null;
            _models.Emp_gender = null;
            _models.Emp_pno = null;
            _models.Emp_designation = null;
        }

    }
}
