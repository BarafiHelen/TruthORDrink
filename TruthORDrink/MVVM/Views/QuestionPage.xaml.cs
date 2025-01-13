using TruthORDrink.MVVM.ViewModel;

namespace TruthORDrink.MVVM.Views
{
    public partial class QuestionPage : ContentPage
    {
        private readonly QuestionViewModel _viewModel;

        public QuestionPage(QuestionViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private void OnAddQuestionClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuestionContentEntry.Text) &&
                !string.IsNullOrWhiteSpace(QuestionCategoryEntry.Text) &&
                !string.IsNullOrWhiteSpace(QuestionLevelEntry.Text))
            {
                _viewModel.AddQuestion(
                    QuestionContentEntry.Text,
                    QuestionCategoryEntry.Text,
                    QuestionLevelEntry.Text
                );

                QuestionContentEntry.Text = string.Empty;
                QuestionCategoryEntry.Text = string.Empty;
                QuestionLevelEntry.Text = string.Empty;
            }
        }
    }
}
