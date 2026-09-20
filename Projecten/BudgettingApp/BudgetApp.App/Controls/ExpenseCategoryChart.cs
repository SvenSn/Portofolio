using BudgetApp.App.ViewModels;

namespace BudgetApp.App.Controls;

public sealed class ExpenseCategoryChart : GraphicsView, IDrawable
{
    public static readonly BindableProperty SlicesProperty = BindableProperty.Create(
        nameof(Slices), typeof(IReadOnlyList<ExpenseSlice>), typeof(ExpenseCategoryChart), null,
        propertyChanged: (view, _, _) => ((ExpenseCategoryChart)view).Invalidate());

    public IReadOnlyList<ExpenseSlice>? Slices
    {
        get => (IReadOnlyList<ExpenseSlice>?)GetValue(SlicesProperty);
        set => SetValue(SlicesProperty, value);
    }

    public ExpenseCategoryChart() => Drawable = this;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var slices = Slices;
        if (slices is null || slices.Count == 0) return;
        var total = slices.Sum(slice => slice.Amount);
        if (total <= 0) return;
        var center = dirtyRect.Center;
        var radius = Math.Min(dirtyRect.Width, dirtyRect.Height) * 0.45f;
        double start = 0;
        for (var index = 0; index < slices.Count; index++)
        {
            var slice = slices[index];
            var end = index == slices.Count - 1 ? 1 : start + (double)(slice.Amount / total);
            var path = new PathF();
            path.MoveTo(center.X, center.Y);
            var steps = Math.Max(1, (int)Math.Ceiling((end - start) * 240));
            for (var step = 0; step <= steps; step++)
            {
                var angle = (start + (end - start) * step / steps) * 2 * Math.PI - Math.PI / 2;
                path.LineTo(center.X + radius * (float)Math.Cos(angle),
                    center.Y + radius * (float)Math.Sin(angle));
            }
            path.Close();
            canvas.FillColor = slice.Color;
            canvas.FillPath(path);
            start = end;
        }
    }
}
