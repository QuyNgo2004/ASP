using System.Reflection;

namespace DangKyHocThuat_Web.Utility
{
    public class CUtility
    {
        public static void Assign_Entity(object p_objSource, object p_objTarget)
        {
            if (p_objSource == null)
                throw new ArgumentNullException(nameof(p_objSource), "Source object không được phép rỗng.");
            if (p_objTarget == null)
                throw new ArgumentNullException(nameof(p_objTarget), "Target object không được phép rỗng.");

            var v_objSource_Type = p_objSource.GetType();
            var v_objTarget_Type = p_objTarget.GetType();

            foreach (PropertyInfo v_objSoucre_Property in v_objSource_Type.GetProperties())
            {
                //Nếu field không được phép đọc thì bỏ qua
                if (v_objSoucre_Property.CanRead == false)
                    continue;

                //Lấy field của target theo name của soucre
                PropertyInfo v_objTarget_Property = v_objTarget_Type.GetProperty(v_objSoucre_Property.Name);

                //Nếu target null hoặc không cho phép ghi dữ liệu lên thì bỏ qua
                if (v_objTarget_Property == null || v_objTarget_Property.CanWrite == false) 
                    continue;

                // Kiểm tra 2 kiểu dữ liệu của 2 field
                if (v_objTarget_Property.PropertyType.IsAssignableFrom(v_objSoucre_Property.PropertyType))
                {
                    var value = v_objSoucre_Property.GetValue(p_objSource, null);
                    v_objTarget_Property.SetValue(p_objTarget, value, null);
                }
            }
        }

    }
}
