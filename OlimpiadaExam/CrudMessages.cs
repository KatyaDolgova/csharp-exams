using System.Windows.Forms;

namespace OlimpiadaExam
{
    internal static class CrudMessages
    {
        public static void ShowStatus(bool result, string action)
        {
            if (result)
            {
                switch (action.ToUpper())
                {
                    case "SAVE":
                        MessageBox.Show("Добавлено", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "UPDATE":
                        MessageBox.Show("Обновлено", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        MessageBox.Show("Удалено", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Что-то пошло не так, попробуйте ещё раз", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
