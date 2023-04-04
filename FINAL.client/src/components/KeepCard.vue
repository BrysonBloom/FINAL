<template>
    <button type="button" class="card" data-bs-toggle="modal" data-bs-target="#KeepModal" @click="getKeepById(keep.id)">
        <img class="img-fluid" :src="keep.img" alt="">
        <div class="card-body text-center">
            {{ keep.name }}
        </div>

    </button>
</template>


<script>
import { Keep } from '../models/Keep';
import { keepsService } from '../services/KeepsService';
import Pop from '../utils/Pop';

export default {
    props: {
        keep: {
            type: Keep,
            required: true
        }
    },
    setup() {


        return {
            async getKeepById(id) {
                try {
                    await keepsService.getKeepById(id);
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>