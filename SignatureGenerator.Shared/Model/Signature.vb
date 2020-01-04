Imports System.Runtime.Serialization

<DataContract>
    Public Class Signature
        <DataMember>
        Public Property TemplateName As String
        <DataMember>
        Public ReadOnly Property TextBlocks As Dictionary(Of String, String) = New Dictionary(Of String, String)()
        <DataMember>
        Public ReadOnly Property Images As Dictionary(Of String, String) = New Dictionary(Of String, String)()
        <DataMember>
        Public Property Person As Person
        <DataMember>
        Public Property LegalInfo As String
    End Class

    <DataContract>
    Public Class Person
        <DataMember>
        Public Property FirstName As String
        <DataMember>
        Public Property LastName As String
        <DataMember>
        Public Property PositionDescription As String
        <DataMember>
        Public ReadOnly Property ContactData As List(Of ContactData) = New List(Of ContactData)()
    End Class

    <DataContract>
    Public Class ContactData
        <DataMember>
        Public Property Description As String
        <DataMember>
        Public Property Value As String
    End Class