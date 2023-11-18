﻿using System.Net;
using OpenAI.ObjectModels.RequestModels;

namespace OpenAI.EndpointProviders;

internal class OpenAiEndpointProvider : IOpenAiEndpointProvider
{
    private readonly string _apiVersion;

    public OpenAiEndpointProvider(string apiVersion)
    {
        _apiVersion = apiVersion;
    }

    public string ModelRetrieve(string model)
    {
        return $"{_apiVersion}/models/{model}";
    }

    public string FileDelete(string fileId)
    {
        return $"{_apiVersion}/files/{fileId}";
    }

    public string CompletionCreate()
    {
        return $"{_apiVersion}/completions";
    }

    public string ChatCompletionCreate()
    {
        return $"{_apiVersion}/chat/completions";
    }

    public string AudioCreateTranscription()
    {
        return $"{_apiVersion}/audio/transcriptions";
    }

    public string AudioCreateTranslation()
    {
        return $"{_apiVersion}/audio/translations";
    }

    public string AudioCreateSpeech()
    {
        return $"{_apiVersion}/audio/speech";
    }
    public string EditCreate()
    {
        return $"{_apiVersion}/edits";
    }

    public string ModelsList()
    {
        return $"{_apiVersion}/models";
    }

    public string FilesList()
    {
        return Files();
    }

    public string FilesUpload()
    {
        return Files();
    }

    public string FileRetrieve(string fileId)
    {
        return $"{_apiVersion}/files/{fileId}";
    }

    public string FileRetrieveContent(string fileId)
    {
        return $"{_apiVersion}/files/{fileId}/content";
    }

    public string FineTuneCreate()
    {
        return $"{_apiVersion}/fine-tunes";
    }

    public string FineTuneList()
    {
        return $"{_apiVersion}/fine-tunes";
    }

    public string FineTuneRetrieve(string fineTuneId)
    {
        return $"{_apiVersion}/fine-tunes/{fineTuneId}";
    }

    public string FineTuneCancel(string fineTuneId)
    {
        return $"{_apiVersion}/fine-tunes/{fineTuneId}/cancel";
    }

    public string FineTuneListEvents(string fineTuneId)
    {
        return $"{_apiVersion}/fine-tunes/{fineTuneId}/events";
    }

    public string FineTuneDelete(string fineTuneId)
    {
        return $"{_apiVersion}/models/{fineTuneId}";
    }

    public string FineTuningJobCreate()
    {
        return $"{_apiVersion}/fine_tuning/jobs";
    }

    public string FineTuningJobList(FineTuningJobListRequest? fineTuningJobListRequest)
    {
        var url = $"{_apiVersion}/fine_tuning/jobs";
        if (fineTuningJobListRequest != null)
        {
            var queryParams = new List<string>();
            if (fineTuningJobListRequest.After != null)
                queryParams.Add($"after={WebUtility.UrlEncode(fineTuningJobListRequest.After)}");
            if (fineTuningJobListRequest.Limit.HasValue)
                queryParams.Add($"limit={fineTuningJobListRequest.Limit.Value}");
        
            if (queryParams.Any())
                url = $"{url}?{string.Join("&", queryParams)}";
        }
        return url;
    }

    public string FineTuningJobRetrieve(string fineTuningJobId)
    {
        return $"{_apiVersion}/fine_tuning/jobs/{fineTuningJobId}";
    }

    public string FineTuningJobCancel(string fineTuningJobId)
    {
        return $"{_apiVersion}/fine_tuning/jobs/{fineTuningJobId}/cancel";
    }

    public string FineTuningJobListEvents(string fineTuningJobId)
    {
        return $"{_apiVersion}/fine_tuning/jobs/{fineTuningJobId}/events";
    }

    public string ModelsDelete(string modelId)
    {
        return $"{_apiVersion}/models/{modelId}";
    }

    public string EmbeddingCreate()
    {
        return $"{_apiVersion}/embeddings";
    }

    public string ModerationCreate()
    {
        return $"{_apiVersion}/moderations";
    }

    public string ImageCreate()
    {
        return $"{_apiVersion}/images/generations";
    }

    public string ImageEditCreate()
    {
        return $"{_apiVersion}/images/edits";
    }

    public string ImageVariationCreate()
    {
        return $"{_apiVersion}/images/variations";
    }

    private string Files()
    {
        return $"{_apiVersion}/files";
    }
    
    public string AssistantCreate()
    {
        return $"{_apiVersion}/assistants";
    }

    public string AssistantRetrieve(string assistantId)
    {
        return $"{_apiVersion}/assistants/{assistantId}";
    }

    public string AssistantModify(string assistantId)
    {
        return $"{_apiVersion}/assistants/{assistantId}";
    }

    public string AssistantDelete(string assistantId)
    {
        return $"{_apiVersion}/assistants/{assistantId}";
    }

    public string AssistantList(AssistantListRequest? assistantListRequest)
    {
        var url = $"{_apiVersion}/assistants";

        if (assistantListRequest != null)
        {
            var queryParams = new List<string>();
            
            if(assistantListRequest.Limit != null)
                queryParams.Add($"limit={assistantListRequest.Limit.Value}");
            if(assistantListRequest.Order != null)
                queryParams.Add($"order={WebUtility.UrlEncode(assistantListRequest.Order)}");
            if(assistantListRequest.After != null)
                queryParams.Add($"after={WebUtility.UrlEncode(assistantListRequest.After)}");
            if(assistantListRequest.Before != null)
                queryParams.Add($"before={WebUtility.UrlEncode(assistantListRequest.Before)}");

            if (queryParams.Any())
                url = $"{url}?{string.Join("&", queryParams)}";
        }

        return url;
    }

    public string AssistantFileCreate(string assistantId)
    {
        return $"{_apiVersion}/assistants/{assistantId}/files";
    }

    public string AssistantFileRetrieve(string assistantId, string fileId)
    {
        return $"{_apiVersion}/assistants/{assistantId}/files/{fileId}";
    }

    public string AssistantFileDelete(string assistantId, string fileId)
    {
        return $"{_apiVersion}/assistants/{assistantId}/files/{fileId}";
    }

    public string AssistantFileList(string assistantId, AssistantFileListRequest? assistantFileListRequest)
    {
        var url = $"{_apiVersion}/assistants/{assistantId}/files";

        if (assistantFileListRequest != null)
        {
            var queryParams = new List<string>();
            
            if(assistantFileListRequest.Limit != null)
                queryParams.Add($"limit={assistantFileListRequest.Limit.Value}");
            if(assistantFileListRequest.Order != null)
                queryParams.Add($"order={WebUtility.UrlEncode(assistantFileListRequest.Order)}");
            if(assistantFileListRequest.After != null)
                queryParams.Add($"after={WebUtility.UrlEncode(assistantFileListRequest.After)}");
            if(assistantFileListRequest.Before != null)
                queryParams.Add($"before={WebUtility.UrlEncode(assistantFileListRequest.Before)}");

            if (queryParams.Any())
                url = $"{url}?{string.Join("&", queryParams)}";
        }
        return url;
    }
}