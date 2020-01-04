Imports System.Net
Imports System.Text
Imports System.Web
Imports Newtonsoft.Json

Public Class Client
    Private _ServiceUrl As String

    Public Sub New(serviceUrl As String)
        _ServiceUrl = serviceUrl
    End Sub


    Public Function GetSignatureData(model As Signature) As String
        Dim serializedModel = GetSerializedModel(model)
        Dim requestData = GetRequestData(serializedModel)
        Dim request = GetRequest(requestData)
        Return GetResponseData(request)
    End Function

    Private Function GetSerializedModel(model As Signature) As String
        Return JsonConvert.SerializeObject(model)
    End Function

    Private Function GetRequestData(data As String) As Byte()
        Dim parameterName = HttpUtility.UrlEncode("signature")
        Dim parameterValue = HttpUtility.UrlEncode(data)
        Dim postData = $"{parameterName}={parameterValue}"
        Return Encoding.ASCII.GetBytes(postData)
    End Function

    Private Function GetRequest(data As Byte()) As HttpWebRequest
        Dim request = HttpWebRequest.Create(_ServiceUrl)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = data.Length
        Dim stream = request.GetRequestStream()
        stream.Write(data, 0, data.Length)
        stream.Close()
        Return request
    End Function

    Private Function GetResponseData(request As HttpWebRequest) As String
        Dim response = request.GetResponse()
        Dim stream = response.GetResponseStream()
        Dim reader = New IO.StreamReader(stream, Encoding.UTF8)
        Dim result = reader.ReadToEnd()
        reader.Close()
        stream.Close()
        Return result
    End Function
End Class
