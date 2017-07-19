using System;
using System.Collections;

namespace TrafficControlSystem
{
	public class AbstractLaneModel {

		private ArrayList listeners = new ArrayList(5);
		private string color;
		private int timer;
		private bool error;
		
		public void notifyChanged(ModelEvent e) {
			// TODO - implement AbstractLaneModel.notifyChanged
			throw new NotImplementedException();
		}
		
	    public void addModelListener(ModelListener l) {
			// TODO - implement AbstractLaneModel.addModelListener
			throw new NotImplementedException();
		}
		
		public void removeModelListener(ModelListener l) {
			// TODO - implement AbstractLaneModel.removeModelListener
			throw new NotImplementedException();
		}

		public String getColor() {
			return this.color;
		}

		public void setColor(string color) {
			this.color = color;
		}

		public int getTimer() {
			return this.timer;
		}
		
		public void setTimer(int timer) {
			this.timer = timer;
		}

		public bool getError() {
			return this.error;
		}
		
		public void setError(bool error) {
			this.error = error;
		}

	}
}