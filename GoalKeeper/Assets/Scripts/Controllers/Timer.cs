using UnityEngine;

namespace GoalKeeper.Controllers
{
    public class Timer : MonoBehaviour
    {
		private float _duration;
		private float _currentTime;

		private bool _started;
		private bool _finished;

		public float Duration
		{
			get { return _duration; }
			set { _duration = value; }
		}
		public bool Started
		{
			get { return _started; }
		}
		public bool Finished
		{
			get { return _finished; }
		}
		private void Update()
		{
			if (_started && !_finished)
			{
				_currentTime += Time.deltaTime;
				if (_currentTime >= _duration)
				{
					_finished = true;
					_started = false;
				}
			}
		}
		public void Run()
		{
			if (_duration > 0)
			{
				_started = true;
				_finished = false;

				_currentTime = 0;
			}
		}
	}
}
