using BudgetApp.App.ViewModels;

namespace BudgetApp.App.Controls;

// Aandeel uitgaven tegenover het resterende bedrag; geen overlappende totalen.
public sealed class FinanceChart : GraphicsView, IDrawable
{
    public static readonly BindableProperty CategoriesProperty = BindableProperty.Create(
        nameof(Categories), typeof(IReadOnlyList<ExpenseSlice>), typeof(FinanceChart), null,
        propertyChanged: (view, _, _) => ((FinanceChart)view).Invalidate());
    public IReadOnlyList<ExpenseSlice>? Categories
    {
        get => (IReadOnlyList<ExpenseSlice>?)GetValue(CategoriesProperty);
        set => SetValue(CategoriesProperty, value);
    }
    public static readonly BindableProperty IncomeProperty = BindableProperty.Create(
        nameof(Income), typeof(decimal), typeof(FinanceChart), 0m,
        propertyChanged: (view, _, _) => ((FinanceChart)view).Invalidate());
    public static readonly BindableProperty ExpensesProperty = BindableProperty.Create(
        nameof(Expenses), typeof(decimal), typeof(FinanceChart), 0m,
        propertyChanged: (view, _, _) => ((FinanceChart)view).Invalidate());
    public decimal Income { get => (decimal)GetValue(IncomeProperty); set => SetValue(IncomeProperty, value); }
    public decimal Expenses { get => (decimal)GetValue(ExpensesProperty); set => SetValue(ExpensesProperty, value); }
    public FinanceChart() => Drawable = this;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var cx = dirtyRect.Center.X;
        var cy = dirtyRect.Center.Y;
        var radius = Math.Min(dirtyRect.Width, dirtyRect.Height) * 0.44f;
        var total = Math.Max(Income, Expenses);
        if (total == 0)
        {
            canvas.FillColor = Color.FromArgb("#94A3B8");
            canvas.FillCircle(cx, cy, radius);
        }
        else
        {
            double start = 0;
            foreach (var category in Categories ?? [])
            {
                var end = Math.Min(1, start + (double)(category.Amount / total));
                Slice(canvas, cx, cy, radius, start, end, category.Color);
                start = end;
            }
            if (Income > Expenses)
                Slice(canvas, cx, cy, radius, start, 1, Color.FromArgb("#22C55E"));
        }
    }

    private static void Slice(ICanvas canvas, float x, float y, float radius, double from, double to, Color color)
    {
        if (to <= from) return;
        var path = new PathF();
        path.MoveTo(x, y);
        var steps = Math.Max(1, (int)Math.Ceiling((to - from) * 180));
        for (var step = 0; step <= steps; step++)
        {
            var angle = (from + (to - from) * step / steps) * 2 * Math.PI - Math.PI / 2;
            path.LineTo(x + radius * (float)Math.Cos(angle), y + radius * (float)Math.Sin(angle));
        }
        path.Close();
        canvas.FillColor = color;
        canvas.FillPath(path);
    }
}
