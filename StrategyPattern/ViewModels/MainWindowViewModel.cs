using System.Collections.ObjectModel;
using Patterns.Domain.Models;
using Patterns.Domain.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace Patterns.Wpf.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private ObservableCollection<ShapeViewModel> _shapes;
    public ObservableCollection<ShapeViewModel> Shapes 
    { 
        get => _shapes;
        set => SetProperty(ref _shapes, value);
    }
    
    public MainWindowViewModel(IShapeService shapeService)
    {
        IReadOnlyList<IShape> shapes = shapeService.GetAllShapes();
        Shapes = new ObservableCollection<ShapeViewModel>(shapes.Select(ShapeViewModelFactory.Create));
    }

    private DelegateCommand _calculateAllAreasCommand;
    public DelegateCommand CalculateAllAreasCommand => _calculateAllAreasCommand ??= new DelegateCommand(ExecuteCalculateAllAreasCommand);

    private void ExecuteCalculateAllAreasCommand()
    {
        foreach (ShapeViewModel shapeViewModel in Shapes)
        {
            shapeViewModel.CalculateArea();
        }
    }
}