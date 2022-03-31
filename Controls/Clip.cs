namespace GraphicsViewBugs.Controls;

public class Clip : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 1;

        LinearGradientPaint gradient = new LinearGradientPaint
        {
            StartColor = Color.FromRgb(103, 103, 103),
            EndColor = Color.FromHsv(226, 18, 100),
            StartPoint = new Point(0.5, 1),
            EndPoint = new Point(0.5, 0)
        };

        var path = new PathF();

        path.MoveTo(50, 50);
        path.LineTo(250, 50);
        path.CurveTo(new PointF(250, 50), new PointF(275, 75), new PointF(250, 100));
        path.LineTo(50, 100);
        path.CurveTo(new PointF(50, 100), new PointF(25, 75), new PointF(50, 50));
        path.Close();

        var fillRect = new RectF(30, 40, 250, 70);

        canvas.SetFillPaint(gradient, fillRect);


        canvas.FillRoundedRectangle(fillRect, 12);

        canvas.DrawPath(path);

        //canvas.ClipPath(path);
        canvas.SetShadow(new SizeF(10, -10), 4, Colors.Grey);
    }
}
