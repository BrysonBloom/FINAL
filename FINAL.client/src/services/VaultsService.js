import { AppState } from "../AppState"
import { api } from "./AxiosService"
import { Keep } from "../models/Keep"
import { Vault } from "../models/Vault"
import { logger } from "../utils/Logger"

class VaultsService {
    async getKeepsByVaultId(id) {
        const res = await api.get('api/vaults/' + id + '/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
    }

    async getVaultsByProfile(profileId) {
        const res = await api.get('api/profiles/' + profileId + '/vaults')
        AppState.vaults = res.data.map(v => new Vault(v))
        logger.log(AppState.vaults)
    }
    async getKeepsByProfile(profileId) {
        const res = await api.get('api/profiles/' + profileId + '/keeps')
        AppState.keeps = res.data.map(v => new Keep(v))
    }
    async getMyVaults() {
        const res = await api.get('account/vaults')
        AppState.myVaults = res.data.map(v => new Vault(v))
        // logger.log(AppState.myVaults)
    }

    async addKeepToVault(vaultId, keepId) {
        const newVault = { vaultId: vaultId, keepId: keepId }
        const res = await api.post('api/vaultKeeps/', newVault)
        AppState.keep.kept++
        logger.log(res.data)
    }
    async getKeepsInVault(vaultId) {
        const res = await api.get('api/vaults/' + vaultId + '/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
        logger.log(AppState.keeps)
    }
    async createVault(formData) {
        const res = await api.post('api/vaults', formData)
        logger.log(res.data)
    }


}

export const vaultsService = new VaultsService
