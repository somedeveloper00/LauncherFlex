using System.Collections.Generic;
using System.IO;
using System.Threading;
using AnimFlex.Sequencer;
using AnimFlex.Sequencer.UserEnd;
using AnimFlex.Tweening;
using LauncherFlex.ListView;
using UnityEngine;

namespace LauncherFlex
{
    public class Manager : MonoBehaviour
    {		
        [SerializeField] private WideListView3D _listView;

        private List<CancellationTokenSource> _currentCancelTokens = new List<CancellationTokenSource>();

        private void Start()
        {
            GlobalInput.mainNav.Enable();
            ReloadGamesListView();
        }

        private void OnDestroy()
        {
            foreach (var source in _currentCancelTokens) source?.Cancel();
        }

        public void ReloadGamesListView()
        {
            // load game views
            if (File.Exists(IOUtils.DATA_SAVE_PATH))
            {
                IOUtils.LoadGameData(
                    (gameDats) =>
                    {
                        if (gameDats == null)
                        {
                            Debug.LogWarning($"Data not readable");
                            return;
                        }

                        _listView.SetItems(gameDats);
                    });
            }
        }
    }
}