using System.Reflection;

namespace ASP_DangKiThi.Utiltity
{
    public static class CUtility
    {
        public static void AssignProperties(object objSource, object objTarget)
        {
            if (objSource == null || objTarget == null)
            {
                throw new ArgumentNullException("Source or Target object cannot be null.");
            }

            var objSourceType = objSource.GetType();
            var objTargetType = objTarget.GetType();

            // Lặp qua tất cả các thuộc tính của đối tượng nguồn
            foreach (PropertyInfo objProperty in objSourceType.GetProperties())
            {
                // Kiểm tra xem đối tượng mục tiêu có thuộc tính tương ứng không
                PropertyInfo objTargetProperty = objTargetType.GetProperty(objProperty.Name);
                if (objTargetProperty != null && objTargetProperty.CanWrite)
                {
                    // Lấy giá trị từ thuộc tính nguồn
                    var value = objProperty.GetValue(objSource);
                    // Gán giá trị vào thuộc tính mục tiêu
                    objTargetProperty.SetValue(objTarget, value);
                }
            }
        }

    }
}
