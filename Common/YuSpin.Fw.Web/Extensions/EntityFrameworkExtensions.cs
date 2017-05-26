using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YuSpin.Fw.Web
{
    public static class EntityFrameworkExtensions
    {
        public static List<SelectListItem> AsDropDownSelectList<TEntity, TKey, TName>(this IEnumerable<TEntity> source,
                                                                                                            Expression<Func<TEntity, TKey>> KeyField,
                                                                                                            Expression<Func<TEntity, TName>> TextField,
                                                                                                            bool allowEmptyItem,
                                                                                                            object selectedValue = null,
                                                                                                            string defaultText = null)
        {

            var keyExpression = KeyField.Body as MemberExpression;
            var textExpression = TextField.Body as MemberExpression;
            var disabledField = typeof(TEntity).GetProperty("Disabled");

            var res = source.Select(x => new SelectListItem
            {
                Value = x.GetType().GetProperty(keyExpression.Member.Name).GetValue(x).ToString(),
                Text = x.GetType().GetProperty(textExpression.Member.Name).GetValue(x).ToString(),
                Disabled = disabledField == null ? false : Convert.ToBoolean(disabledField.GetValue(x)),
                Selected = selectedValue != null &&
                    Object.Equals(x.GetType().GetProperty(keyExpression.Member.Name).GetValue(x), selectedValue)
            })
                .ToList();

            if (allowEmptyItem)
                res.Insert(0, new SelectListItem() { Text = defaultText, Value = string.Empty });

            return res.ToList();
        }
    }
}
