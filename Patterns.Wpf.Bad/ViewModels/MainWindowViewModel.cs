using System.Collections.ObjectModel;
using Patterns.Wpf.Bad.Managers;
using Patterns.Wpf.Bad.Models;
using Patterns.Wpf.Bad.ViewModels.Shapes;
using Prism.Commands;
using Prism.Mvvm;

namespace Patterns.Wpf.Bad.ViewModels;

public partial class MainWindowViewModel : BindableBase
{
    private readonly ShapesManager _shapesManager = new ShapesManager();

    private ObservableCollection<IShapeViewModel> _shapes = new();
    public ObservableCollection<IShapeViewModel> Shapes 
    { 
        get => _shapes;
        set => SetProperty(ref _shapes, value);
    }

    public MainWindowViewModel()
    {
        _shapesManager.LoadShapes();
        Shapes = new ObservableCollection<IShapeViewModel>(_shapesManager.GetShapes().Select(x =>
        {
            IShapeViewModel shapeViewModel;
            if (x is Circle circle)
            {
                shapeViewModel = new CircleViewModel(circle);
            }
            else if (x is Rectangle rectangle)
            {
                shapeViewModel = new RectangleViewModel(rectangle);
            }
            else
            {
                shapeViewModel = null;
            }

            return shapeViewModel;
        }));
        
    }

    private DelegateCommand<object> _buttonClickedCommand;
    public DelegateCommand<object> ButtonClickedCommand => _buttonClickedCommand = new DelegateCommand<object>(ExecuteButtonClickedCommand);

    private void ExecuteButtonClickedCommand(object sender)
    {
        if (sender is IShapeViewModel shapeViewModel)
        {
            if (shapeViewModel.Action == "CalculateArea")
            {
                _shapesManager.CalculateShapeArea(shapeViewModel);
                // if (shapeViewModel is RectangleViewModel rectangle)
                // {
                //     rectangle.Area = rectangle.Width * rectangle.Height;
                // }
                // else if (shapeViewModel is CircleViewModel circle)
                // {
                //     circle.Area = Math.PI * Math.Pow(circle.Width / 2, 2);
                // }
            }
        }
    }

    private DelegateCommand _calculateAllAreasCommand;
    public DelegateCommand CalculateAllAreasCommand => _calculateAllAreasCommand ??= new DelegateCommand(ExecuteCalculateAllAreasCommand);

    private void ExecuteCalculateAllAreasCommand()
    {
        foreach (var shapeViewModel in Shapes)
        {
            _shapesManager.CalculateShapeArea(shapeViewModel);
            // if (shapeViewModel is RectangleViewModel rectangle)
            // {
            //     rectangle.Area = rectangle.Width * rectangle.Height;
            // }
            // else if (shapeViewModel is CircleViewModel circle)
            // {
            //     circle.Area = Math.PI * Math.Pow(circle.Width / 2, 2);
            // }
        }
    }   
}