<template>
    <div class="card" @click="getKeepById(keep.id)" style="background-position: center; background-size: cover;"
        :style="{ backgroundImage: `url(${keep.img})` }">
        <img class="img-fluid rounded invis" :src="keep.img" alt="">
        <div class="card-body text-light justify-content-between p-0 row">
            <div class="col-9 d-flex align-items-center ps-4">
                <p class="fs-3 shadow-text m-0">{{ keep.name }}</p>
            </div>
            <div class="col-3 py-2 px-4 text-end"><img class="rounded-circle" style="height: 40px;"
                    :src="keep.creator.picture" alt=""></div>

        </div>

    </div>
</template>


<script>
import { Keep } from '../models/Keep';
import { keepsService } from '../services/KeepsService';
import Pop from '../utils/Pop';
import KeepModal from './KeepModal.vue';

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
    },
    components: { KeepModal }
}
</script>


<style lang="scss" scoped>
.shadow-text {
    text-shadow: 1px .5px 2px black;
}

.invis {
    opacity: 0%;
}
</style>