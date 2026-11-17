using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfMVVM.Models;

//Ця модель буде вміти реагувати на зміни 
//Підтримується можливість зміни властивостей = Property
class UserVM : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _name;
    private string _image;
    private string _phone;
    public string Name
    {
        get { return _name; }
        set
        {
            if(_name!=value)
            {
                _name = value;
                INotifyPropertyChanged(nameof(Name));
            }
        }
    }
    public string Image
    {
        get { return _image; }
        set
        {
            if(_image!= value)
            {
                _image = value;
                INotifyPropertyChanged(nameof(Image));
            }
        }
    }
    public string Phone
    {
        get { return _phone; }
        set
        {
            if(_phone != value)
            {
                _phone = value;
                INotifyPropertyChanged(nameof(Phone));
            }
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
        
    public void INotifyPropertyChanged(string propName)
    {
        PropertyChanged?
            .Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
