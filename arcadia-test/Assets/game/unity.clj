;; https://raw.githubusercontent.com/jblouir/arcadia-roguelike/be910c146fb063e57a98c2755bf1aded231d78db/Assets/game/unity.clj

(ns game.unity
    "Contains wrappers for some unity interop calls to make
       them more idiomatic to Clojure(and easier to type and read!), 
       as well as some helper methods that interact with the coroutiner to 
       make it easier to execute coroutines, invocations, ect from Clojure!"
      (:use arcadia.core
                    arcadia.linear)
      (:import Coroutiner arcadia.core.server clojure.core.server))

(def epsilon (. System.Single Epsilon))

(defn delta-time []
    (. UnityEngine.Time deltaTime))

(defn move-towards [start end step]
    (. UnityEngine.Vector2 (MoveTowards start end step)))

(defn activate! [go]
    (.SetActive go true))

(defn deactivate! [go]
    (.SetActive go false))

(defn set-parent-go!
    "Convenience method for parenting at the GameObject level"
      [child-go parent-go]
        (. (. child-go transform)
                (SetParent (. parent-go transform))))

(defn qidentity [] (.. UnityEngine.Quaternion identity))

(defn log-b
    "Wrapper for the Unity Mathf.Log function, calls log n to base b"
      [n b]
        (int (.. UnityEngine.Mathf (Log n b))))

(defn is-mobile? []
    (or (= (. UnityEngine.Application platform) (. UnityEngine.RuntimePlatform Android))
              (= (. UnityEngine.Application platform) (. UnityEngine.RuntimePlatform IPhonePlayer))))

(defn abs [n]
    (. UnityEngine.Mathf (Abs n)))

(defn any-key []
    (. UnityEngine.Input anyKey))

