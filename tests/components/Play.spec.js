import { mount } from '@vue/test-utils';

import Play from '../../src/components/Play.vue';

describe('Play.vue', () => {

  test('should set data on mount', ()=> {

    var title = 'Superman';
    var wrapper = mount(Play, { propsData: { title: title }});

    expect(wrapper.vm.title).toEqual(title);
    expect(wrapper.vm.moviePath).toEqual('/api/play/?title=' + title);
  });

});