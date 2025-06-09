namespace FaceApi.DTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public List<int> SchoolIds { get; set; }
        public string BasePhotoUrl { get; set; }
        public string AzurePersonId { get; set; }
    }
}
