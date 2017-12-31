using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Filtering;
using Tekla.Structures.Filtering.Categories;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Filters
{
	public partial class FilterForm : Form
	{
		private readonly Model _model = new Model();
		private Dictionary<int, Color> _phaseColors;

		public FilterForm()
		{
			InitializeComponent();
			ModelObjectVisualization.ClearAllTemporaryStates();
		}

		private void FilterForm_Load(object sender, EventArgs e)
		{
			var phases = _model.GetPhases()
				.OfType<Phase>()
				.ToList()
				.Select(p => new PhaseView
				{
					Number = p.PhaseNumber,
					Name = p.PhaseName,
					Comment = p.PhaseComment,
					Current = p.IsCurrentPhase == 1,
					Visible = false
				}).ToList();

			phases.Sort((a, b) => a.Number.CompareTo(b.Number));

			dataGridViewPhases.DataSource = phases;

			var names = GetPartNames();
			names.Insert(0, string.Empty);
			listBoxName.DataSource = names;

			InitializePhaseColors();
		}

		private void buttonFilter_Click(object sender, EventArgs e)
		{
			var phaseViews = dataGridViewPhases.Rows
				.OfType<DataGridViewRow>()
				.Select(r => r.DataBoundItem as PhaseView)
				.ToList();

			var visible = phaseViews.Where(p => p.Visible).ToList();

			ModelObjectVisualization.SetTransparencyForAll(TemporaryTransparency.TRANSPARENT);

			ObjectFilterExpressions.Type objectType = new ObjectFilterExpressions.Type();
			NumericConstantFilterExpression type = new NumericConstantFilterExpression(TeklaStructuresDatabaseTypeEnum.PART);

			PartFilterExpressions.Name partName = new PartFilterExpressions.Name();
			StringConstantFilterExpression name = new StringConstantFilterExpression(listBoxName.SelectedItem.ToString());

			//ObjectFilterExpressions.Phase objectPhase = new ObjectFilterExpressions.Phase();
			//NumericConstantFilterExpression phase = new NumericConstantFilterExpression(p.Number);
			//var expression1 = new BinaryFilterExpression(objectPhase, NumericOperatorType.IS_EQUAL, phase);
			var expression2 = new BinaryFilterExpression(objectType, NumericOperatorType.IS_EQUAL, type);
			var expression3 = new BinaryFilterExpression(partName, StringOperatorType.STARTS_WITH, name);

			BinaryFilterExpressionCollection filterCollection =
				new BinaryFilterExpressionCollection
				{
					//new BinaryFilterExpressionItem(expression1),
					new BinaryFilterExpressionItem(expression2, BinaryFilterOperatorType.BOOLEAN_AND),
				};

			if(!string.IsNullOrEmpty(listBoxName.SelectedItem.ToString()))
				filterCollection.Add(new BinaryFilterExpressionItem(expression3));

			ModelObjectEnumerator.AutoFetch = true;
			var result = _model.GetModelObjectSelector().GetObjectsByFilter(filterCollection);
			if (result.GetSize() < 1) return;

			var parts = result.ToAList<ModelObject>();

			var partsByPhase = parts.AsParallel().ToLookup(p =>
			{
				p.GetPhase(out Phase phase);
				return phase.PhaseNumber;
			});

			visible.ForEach(p =>
			{
				ModelObjectVisualization.SetTemporaryState(partsByPhase[p.Number].ToList(), _phaseColors[p.Number]);
			});
		}

		private void InitializePhaseColors()
		{
			_phaseColors = new Dictionary<int, Color>
			{
				{1, new Color(1, 0, 0)},
				{2, new Color(0, 1, 0)},
				{3, new Color(0, 0, 1)},
				{4, new Color(1, 1, 0)},
				{5, new Color(1, 1, 1)},
				{6, new Color(0, .25, 0)},
				{7, new Color(0, 0, .25)},
				{8, new Color(1, 0, 1)},
				{9, new Color(0, 1, 1)},
				{10, new Color(0, 1, .5)},
				{11, new Color(.5, .5, .5)},
				{12, new Color(.5, 0, 0)},
				{13, new Color(0, .5, 0)},
				{14, new Color(.75, 0, 0)},
				{15, new Color(0, .75, 0)},
				{16, new Color(0, 0, .75)},
				{17, new Color(.75, .75, 0)},
				{18, new Color(.75, .75, .75)},
				{19, new Color(0, .3, 0)},
				{20, new Color(0, 0, .3)},
				{21, new Color(.3, 0, .3)},
				{22, new Color(0, .3, .3)},
				{23, new Color(0, .3, .5)},
				{99, new Color(.5, .3, .5)},
			};
		}

		private List<string> GetPartNames()
		{
			ObjectFilterExpressions.Type objectType = new ObjectFilterExpressions.Type();
			NumericConstantFilterExpression type = new NumericConstantFilterExpression(TeklaStructuresDatabaseTypeEnum.PART);

			var expression2 = new BinaryFilterExpression(objectType, NumericOperatorType.IS_EQUAL, type);

			BinaryFilterExpressionCollection filterCollection =
				new BinaryFilterExpressionCollection
				{
					new BinaryFilterExpressionItem(expression2)
				};

			ModelObjectEnumerator.AutoFetch = true;
			var result = _model.GetModelObjectSelector().GetObjectsByFilter(filterCollection);

			var parts = result.ToAList<Part>();

			var names = parts.Select(p => p.Name).Distinct().OrderBy(n => n).ToList();

			return names;
		}
	}
}
