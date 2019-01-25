import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setPublicKeeps(state, keeps) {
      state.keeps = keeps
    },
    setMyVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch('getPublicKeeps')
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
          dispatch('getPublicKeeps')
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', {})
          router.push({ name: 'login' })
        })
    },
    getPublicKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setPublicKeeps', res.data)
        })
    },
    addKeep({ commit, dispatch }, newKeep) {
      api.post('keeps', newKeep)
        .then(res => {
          commit('setPublicKeeps', res.data)
          dispatch('getPublicKeeps')
        })
    },
    getVaults({ commit, dispatch }, newKeep) {
      api.get('vaults')
        .then(res => {
          commit('setMyVaults', res.data)
        })
    },
    addVault({ commit, dispatch }, newVault) {
      api.post('vaults', newVault)
        .then(res => {
          commit('setMyVaults', res.data)
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete('vaults/' + vaultId)
        .then(res => {
          dispatch('getVaults')
        })
    },
    getVaultKeeps({ commit, dispatch }, vaultId) {
      api.get('vaultkeeps/' + vaultId)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },
    saveKeepToVault({ commit, dispatch }, payload) {
      api.post('vaultkeeps/', payload)
        .then(res => {
          window.alert("You saved the Keep!")
          //api.put to keepsController to increment keeps/saves
          dispatch('incrementKeeps', payload.data)
        })
        .catch(e => {
          console.error(e)
          window.alert("Sorry, you cant Keep this more than once..")
        })
    },
    deleteKeep({ commit, dispatch }, keepId) {
      api.delete('keeps/' + keepId)
        .then(res => {
          dispatch('getPublicKeeps')
        })
    },
    removeKeep({ commit, dispatch }, payload) {
      api.put('vaultkeeps/', payload)
        .then(res => {
          dispatch('getVaultKeeps', payload.vaultId)
        })
    },
    incrementKeeps({ commit, dispatch }, keep) {
      //api.put to keepsController to increment keeps/saves
      keep.keeps++
      api.put('keeps', keep)
        .then(res => {
          dispatch('getPublicKeeps')
        })
    },
    incrementViewed({ commit, dispatch }, keep) {
      keep.views++
      api.put('keeps', keep)
        .then(res => {
          dispatch('getPublicKeeps')
        })
    }
  }
})