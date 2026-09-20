using Microsoft.AspNetCore.Mvc;

public sealed class FileCallbackResult : FileResult
{
    private readonly Func<Stream, ActionContext, Task> _callback;

    public FileCallbackResult(string contentType, Func<Stream, ActionContext, Task> callback)
        : base(contentType)
    {
        _callback = callback;
    }

    public override async Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;
        response.ContentType = ContentType;

        if (!string.IsNullOrEmpty(FileDownloadName))
        {
            response.Headers.ContentDisposition = $"attachment; filename=\"{FileDownloadName}\"";
        }

        await _callback(response.Body, context);
    }
}
